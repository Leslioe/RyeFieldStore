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
        /// ���س���������Ϊ����
        /// </summary>
        private IEnumerator LoadScenseActive(string sceneName)//����һ��Я��,loadSceneAsync�Ǻ�̨�첽����,�������ģʽ������ԭ���ĳ��������
        {
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);//��һ������˳�������һ���������һ������ĳ�������ȥ�����
            SceneManager.SetActiveScene(newScene);
        }
    }
}

