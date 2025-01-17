using Services.Input;

namespace Infrastructure
{
    public class Game
    {
        public static IInputService InputService;
        public readonly GameStateMachine StateMachine;

        public Game()
        {
            StateMachine = new GameStateMachine();
        }
    }
}