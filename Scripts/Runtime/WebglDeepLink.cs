using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Events;

namespace CodySource
{
    public class WebglDeepLink : MonoBehaviour
    {

        #region PROPERTIES

        /// <summary>
        /// The available link events
        /// </summary>
        public List<LinkEvent> linkEvents;

        /// <summary>
        /// Singleton
        /// </summary>
        public static WebglDeepLink instance
        {
            get
            {
                if (_instance == null)
                {
                    WebglDeepLink[] _all = FindObjectsOfType<WebglDeepLink>();
                    _instance = _all.Length > 0 ? _all[0] : null;
                    if (_instance != null) return _instance;
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _instance = obj.AddComponent<WebglDeepLink>();
                }
                return _instance;
            }
        }
        private static WebglDeepLink _instance;

        #endregion

        #region PUBLIC METHODS

        /// <summary>
        /// Get the deep link
        /// </summary>
        public static void GetDeepLinkToPage() => GetDeepLink();

        [DllImport("__Internal")]
        private static extern void GetDeepLink();

        /// <summary>
        /// The response from the Get Deep Link Call
        /// </summary>
        /// <param name="pLink"></param>
        public void RespondDeepLink(string pLink) => linkEvents.Find(e => e.name == pLink)?.onLinkEvent?.Invoke(pLink);

        #endregion

        #region PUBLIC STRUCTS

        [System.Serializable]
        public class LinkEvent
        {
            public string name;
            public UnityEvent<string> onLinkEvent;
        }

        #endregion

    }
}