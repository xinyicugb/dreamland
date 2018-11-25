
using System;

namespace Dreamland
{
    public class GSManager
    {
        GameState curState;
        GameState nextState;
        private static GSManager instance;
        public static GSManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new GSManager();
                return instance;
            }
        }
        private GSManager()
        {
        }
        public void Init()
        {
            //ChangeGameState(new GSLogIn());
        }

        public void Update()
        {
            if(nextState != null)
            {
                if (curState != null)
                    curState.OnExitState();
                curState = nextState;
                nextState = null;
                curState.OnEnterState();
            }
            if (curState != null)
                curState.Update();
        }

        public void OnGUI()
        {
            if (curState != null)
                curState.OnGUI();
        }
        public void ChangeGameState(GameState state)
        {
            nextState = state;
        }
        public GameState GetCurrentGameState()
        {
            return curState;
        }

        public void OnDestroy()
        {
            if (curState != null)
                curState.OnExitState();
        }

        public void OnApplicationPause(bool status)
        {
            if(curState != null)
            {
                curState.OnApplicationPause(status);
            }
        }
    }
}