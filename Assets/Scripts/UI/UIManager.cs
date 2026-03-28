using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public void Quit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
        
        public void SetMiniMap()
        {
            GameManager.instance.SetMiniMap();
        }
    }
}
