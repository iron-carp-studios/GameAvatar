using UnityEngine;

namespace IronCarpStudios.Unity.Avatar
{
    [RequireComponent(typeof(AvatarStatController))]
    public abstract class GameAvatar : MonoBehaviour
    {
        private AvatarStatController _statControllerRef;
        public AvatarStatController Stats => _statControllerRef;

        private GameObject _avatarMesh;
        public GameObject Mesh => _avatarMesh;

        protected abstract string MeshKey { get; }

        protected virtual void Awake()
        {
            _statControllerRef = GetComponent<AvatarStatController>();
            _avatarMesh = transform.Find(MeshKey).gameObject;
        }
    }
}
