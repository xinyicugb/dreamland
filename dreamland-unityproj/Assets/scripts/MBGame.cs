using UnityEngine;
using System.Collections;
using System.IO;

namespace Dreamland
{
    public class MBGame : MonoBehaviour
    {
        //Map map;
        //BattleLogicConnector scene;
        GSManager gsManager;
        static MBGame instance;
        string fullPath;

        public static MBGame Instance
        {
            get
            {
                return instance;
            }
        }
        // Use this for initialization
        void Start()
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            gsManager = GSManager.Instance;
            gsManager.Init();

            gsManager.ChangeGameState(new GSLogIn());


            InitLog();
        }

        void InitLog()
        {

            fullPath = Application.persistentDataPath + "/logger.txt";
            Debug.LogWarning("Log存放位置："+fullPath);
            if (!Directory.Exists(fullPath))
            {
                FileStream fs = File.Create(fullPath);
                fs.Close();
                Application.logMessageReceived += logCallBack;
            }
            else
            {
                Debug.LogError("directory is not exist");
            }
        }

        private void logCallBack(string condition, string stackTrace, LogType type)
        {
            //关闭写磁盘的Log
            if (File.Exists(fullPath) && (type == LogType.Error || type == LogType.Exception || type == LogType.Warning))
            {
                using (StreamWriter sw = File.AppendText(fullPath))
                {
                    sw.WriteLine(System.DateTime.Now.ToString() + condition);
                    sw.WriteLine(stackTrace);
                }
            }
        }
        void OnDestroy()
        {
            if (gsManager != null)
            {
                gsManager.OnDestroy();
            }
        }
        

        // Update is called once per frame
        void Update()
        {
            //scene.Update();
            //map.Update();

            gsManager.Update();
        }

        void OnGUI()
        {
            //scene.OnGUI();
            gsManager.OnGUI();
        }

        private void OnApplicationPause(bool pause)
        {
        }

        private void OnApplicationQuit()
        {
        }
        
    }

}