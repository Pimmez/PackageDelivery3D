using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dit is een basis interface met simpelen methodes.
public interface IInput
{
	void Movement();
}

/// <summary>
/// Dit is een generic interface where T is de placeholder voor een data type dat in de geimplimenteerde class wordt toegevoegd.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IDamageable<T>
{
	void Damage(T _damageTaken);
}