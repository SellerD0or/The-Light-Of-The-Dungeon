using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EggData", menuName = "GameForGrEl/EggData", order = 1)]
public class EggData : ScriptableObject {
        private Character _character ;

      public Character Character { get => _character; set => _character = value; }

  
}
