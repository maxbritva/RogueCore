using Services.Input;
using UnityEngine;

namespace Infrastructure
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        public BootstrapState(GameStateMachine gameStateMachine) => _gameStateMachine = gameStateMachine;

        public void Enter()
        {
            RegisterServices();
        }

        public void Exit()
        {
           
        }
        
        private void RegisterServices()
        {
            Game.InputService = RegisterInputService();
            Debug.Log("registered");
        }

        private IInputService RegisterInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
            {
                return new MobileInputService();
            }
        }
    }
}