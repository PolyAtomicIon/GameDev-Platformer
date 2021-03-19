using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public interface IDamagable
{
	float Health { get; set; }
	void TakeDamage (float damage);
}