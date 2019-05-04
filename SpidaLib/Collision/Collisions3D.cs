using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Point = UnityEngine.Vector3;
public partial class Collisions3D : MonoBehaviour {

	#region 3D Point
	//Point is assigned to a Vector3 in the using NameSpace.(SEE ABOVE FOR MORE INFO)
	#endregion

	#region 3D Collisions
	/// <summary>
	/// Collision between two SphereColliders.
	/// </summary>
	/// <returns><c>true</c>, if spherecolliders collide, <c>false</c> otherwise.</returns>
	/// <param name="sphere1">Sphere1.</param>
	/// <param name="sphere2">Sphere2.</param>
	public static bool SphereColliderCollision(SphereCollider sphere1,SphereCollider sphere2){
        float radiiSum = sphere1.radius + sphere2.radius;
		float distanceSQ = Vector3.SqrMagnitude(sphere1.transform.position - sphere2.transform.position);
		return distanceSQ <= radiiSum * radiiSum;
	}
	/// <summary>
	/// Collision between two Box Colliders.
	/// </summary>
	/// <returns><c>true</c>, if boxcolliders collide, <c>false</c> otherwise.</returns>
	/// <param name="aabb1">Aabb1.</param>
	/// <param name="aabb2">Aabb2.</param>
	public static bool BoxColliderCollision(BoxCollider aabb1,BoxCollider aabb2){
		Point aMin = aabb1.bounds.min;
		Point aMax = aabb1.bounds.max;
		Point bMin = aabb2.bounds.min;
		Point bMax = aabb2.bounds.max;
		return (aMin.x <= bMax.x && aMax.x >= bMin.x) && (aMin.y <= bMax.y && aMax.y >= bMin.y) && (aMin.z <= bMax.z && aMax.z >= bMin.z);
	}
	#endregion
}
