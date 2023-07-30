using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Graup_of_Runner.Scripts.Camera
{
    public class CameraController : MonoBehaviour
    {
        public static CameraController Instance;
        [SerializeField] private CameraData[] cameraData;
        private CameraData _currentCamera;
        private bool HasCam => _currentCamera != null;


        private void Awake()
        {
            Instance = this;
            ChangeCamera(CameraType.StartCamera);
        }

        public void ChangeCamera(CameraType cameraType)
        {
            if (HasCam)
                _currentCamera.camera.enabled = false;
            _currentCamera = cameraData.FirstOrDefault(x => x.cameraType == cameraType);
            _currentCamera!.camera.enabled = true;

        }
    }
}
