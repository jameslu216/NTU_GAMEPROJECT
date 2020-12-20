using System;
using UniRx;
using UnityEngine;

namespace BombShooting.Utils
{
    public static class TransformExtension
    {
        public static IObservable<Vector3> Follow(
            this Transform self,
            Transform other,
            float smooth = 0.87f,
            bool lockX = false,
            bool lockY = false,
            bool lockZ = false
        )
        {
            Vector3 backupPosition = self.position;
            return other
                .ObserveEveryValueChanged(t => t.position)
                .Do(pos =>
                {
                    var newPosition = Vector3.Lerp(self.position, pos, smooth);
                    if(lockX) newPosition.x = backupPosition.x;
                    if(lockY) newPosition.y = backupPosition.y;
                    if(lockZ) newPosition.z = backupPosition.z;
                    self.position = newPosition;
                });
        }
    }
}