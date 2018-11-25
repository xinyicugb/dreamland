
namespace Dreamland
{
    public enum GSType
    {
        None = 0,
        LogIn,
        Lobby,
        Battle,
    }
    public class GameState
    {
        public virtual void Update()
        {

        }
        public virtual void OnGUI()
        {

        }
        public virtual void OnEnterState()
        {

        }
        public virtual void OnExitState()
        {

        }

        public virtual void OnApplicationPause(bool status)
        {

        }
        public virtual GSType GetGSType()
        {
            return GSType.None;
        }
    }

}
