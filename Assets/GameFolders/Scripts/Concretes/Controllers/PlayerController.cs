using UdemyProject2.Abstracts.Inputs;
using UdemyProject2.Animations;
using UdemyProject2.Combats;
using UdemyProject2.Inputs;
using UdemyProject2.Movements;
using UdemyProject2.ExtensionMethods;
using UdemyProject2.Uis;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] AudioClip _deadClip;
        bool _isJump;
        float vertical;
        float horizontal;
        IPlayerInput _input;
        Mover _mover;
        Jump _jump;
        Flip _flip;
        CharacterAnimation _characterAnimation;
        OnGround _onGround;
        Climbing _climbing;
        Health _health;
        Damage _damage;
        AudioSource _audioSource;
        public static System.Action<AudioClip> OnPlayerDead;
        //SpriteRenderer renderer;
        private void Awake()
        {
            _jump = GetComponent<Jump>();
            _mover = GetComponent<Mover>();
            _flip = GetComponent<Flip>();
            _characterAnimation = GetComponent<CharacterAnimation>();
            _input = new PcInput();
            _onGround = GetComponent<OnGround>();
            _climbing = GetComponent<Climbing>();
            _health = GetComponent<Health>();
            _damage = GetComponent<Damage>();
            _audioSource = GetComponent<AudioSource>();
            //renderer = GetComponentInChildren<SpriteRenderer>();
        }
        private void OnEnable()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();
            if (gameCanvas!=null)
            {
                _health.OnDead += gameCanvas.ShowGameOverPanel;
                DisplayHealth displayHealth=gameCanvas.GetComponentInChildren<DisplayHealth>();
                _health.OnHealthChanged += displayHealth.IncreaseHealth;
                displayHealth.IncreaseHealth(3);
            }
            _health.OnDead += () => OnPlayerDead.Invoke(_deadClip);
            _health.OnHealthChanged += PlayOnHit;
        }
        private void Update()
        {
            if (_health.IsDead) return;
            horizontal = _input.Horizontal;
            vertical = _input.Vertical;
            if (_input.IsJump&&_onGround.IsOnGround&&!_climbing.IsClimbing)
            {
                _isJump = true;
            }
            _characterAnimation.MoveAnimation(horizontal);
            _characterAnimation.JumpAnimation(!_onGround.IsOnGround && !_climbing.IsClimbing);
            _characterAnimation.ClimbAnimation(_climbing.IsClimbing);
        }
        private void FixedUpdate()
        {
            _climbing.ClimbAction(vertical);
            _mover.HorizontalMove(horizontal);
            _flip.Flipcharacter(horizontal);
            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }
       
            //renderer.flipX = Mathf.Sign(horizontal) > 0 ? false : true;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.ObjectHasHealth();
            if (health!=null&&collision.WasHitTopSide())
            {
                health.TakeHit(_damage);
                _jump.JumpAction();
            }
        }
        private void PlayOnHit(int score)
        {
            _audioSource.Play();
        }
    }
}