using UnityEngine;

namespace IronCarpStudios.Unity.Avatar
{
    [RequireComponent(typeof(GameAvatar))]
    public class GameAvatarComponent : MonoBehaviour
    {
        private GameAvatar _avatarRef;
        public GameAvatar Avatar => _avatarRef;

        protected virtual void Awake()
        {
            _avatarRef = GetComponent<GameAvatar>();
        }
    }
}
