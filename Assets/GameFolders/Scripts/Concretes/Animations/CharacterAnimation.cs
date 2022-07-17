using UnityEngine;

namespace UdemyProject2.Animations
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        Animator _animator;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        public void MoveAnimation(float horizontal)
        {
            float mathfValue = Mathf.Abs(horizontal);
            if (_animator.GetFloat("moveSpeed") == mathfValue) return;
            _animator.SetFloat("moveSpeed", mathfValue);
        }
        public void JumpAnimation(bool _isJump)
        {
            if (_isJump == _animator.GetBool("isJump")) return;
            _animator.SetBool("isJump", _isJump);
        }
        public void ClimbAnimation(bool isClimbing)
        {
            if (isClimbing == _animator.GetBool("isClimb")) return;
            _animator.SetBool("isClimb", isClimbing);
        }
    }
}