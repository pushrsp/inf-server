using Google.Protobuf.Protocol;
using Server.Data;

namespace Server.Game
{
    public class ProjectTile : GameObject
    {
        public Skill Data { get; set; }

        public ProjectTile()
        {
            ObjectType = GameObjectType.Projectile;
        }
    }
}