using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Damageable { // Controls the health

    void TakeDamage(int damage); // WIP: needs to include other factors such as force, direction, status, element, etc.
}
