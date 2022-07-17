using UdemyProject2.Animations;
using UdemyProject2.Combats;
using UdemyProject2.Movements;
using UdemyProject2.ExtensionMethods;
using UnityEngine;
using System.Collections;

namespace UdemyProject2.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] AudioClip _clip;
        Mover _mover;
        Animator _animation;
        Health _health;
        Flip _flip;
        OnReachedEdge _onReached;
        Damage _damage;
        float _direction;

        public static System.Action<AudioClip> OnEnemyDead;
        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _animation = GetComponent<Animator>();
            _health = GetComponent<Health>();
            _flip = GetComponent<Flip>();
            _onReached = GetComponent<OnReachedEdge>();
            _damage = GetComponent<Damage>();
            _direction = 1f;
        }
        private void OnEnable()
        {
            _health.OnDead += DeadAction;
            _health.OnDead += () => OnEnemyDead.Invoke(_clip);
        }
        private void FixedUpdate()
        {
            if (_health.IsDead) return;
            _mover.HorizontalMove(_direction);
        }
        private void LateUpdate()
        {
            if (_health.IsDead) return;
            if (_onReached.ReachedEdge())
            {
                _direction *= -1f;
                _flip.Flipcharacter(_direction);
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.ObjectHasHealth();
            if (health!=null&&collision.WasHitLeftOrRightSide())
            {

                health.TakeHit(_damage);
            }
        }
        private void DeadAction()
        {
            StartCoroutine(DeadActionAsync());
        }
        IEnumerator DeadActionAsync()
        {
            _animation.SetTrigger("Dead");
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);
        } 
    }
}