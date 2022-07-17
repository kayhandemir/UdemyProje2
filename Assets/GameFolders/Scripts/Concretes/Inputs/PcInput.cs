using UdemyProject2.Abstracts.Inputs;
using UnityEngine;

namespace UdemyProject2.Inputs
{
    public class PcInput:IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        public bool IsJump => Input.GetButtonDown("Jump");
    }
}