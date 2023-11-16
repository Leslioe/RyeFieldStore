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
        /// <summary>
        /// �����л�
        /// </summary>
        /// <param name="sceneName">Ŀ�곡��</param>
        /// <param name="tagetPosition">Ŀ��λ��</param>
        /// <returns></returns>
        private IEnumerator Transtion(string sceneName, Vector3 tagetPosition)
        {
            EventHandler.CallBeforeSceneUnloadEvent();
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
         
            yield return LoadScenseActive(sceneName);
            EventHandler.CallmovePosition(tagetPosition);
            EventHandler.CallafterSceneUnloadEvent();
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

