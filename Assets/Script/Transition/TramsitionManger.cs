using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace MFarm.Transtion
{
    public class TramsitionManger : MonoBehaviour
    {
        public string startSceneName = string.Empty;
        private void OnEnable()
        {
            EventHandler.TransitionEvent += OnTransitionEvent;
        }

        private void OnDisable()
        {
            EventHandler.TransitionEvent -= OnTransitionEvent;
        }

        private void OnTransitionEvent(string sceneTogo, Vector3 positionTogo)
        {
            StartCoroutine(Transtion(sceneTogo, positionTogo));
        }

        private void Start()
        {
            StartCoroutine(LoadScenseActive(startSceneName));
        }
        private IEnumerator Transtion(string sceneName, Vector3 tagetPosition)
        {
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            yield return LoadScenseActive(sceneName);
        }
        /// <summary>
        /// 加载场景并设置为激活
        /// </summary>
        private IEnumerator LoadScenseActive(string sceneName)//启用一个携程,loadSceneAsync是后台异步加载,后面这个模式，是在原来的场景里添加
        {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);//上一步添加了场景，这一步返回最后一个激活的场景并且去添加他
            SceneManager.SetActiveScene(newScene);
        }
    }
}

