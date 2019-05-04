using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScreenUtil:MonoBehaviour {
	static Vector3 startCoord;
	static Vector3 endCoord;
	static Rect cameraRect;
	
	// Use this for initialization
	void Start () {
		startCoord = Camera.main.ScreenToWorldPoint(Vector3.zero);
		endCoord = Camera.main.ScreenToWorldPoint(new Vector3(
			Camera.main.pixelWidth,Camera.main.pixelHeight
		));
		cameraRect = new Rect (
			startCoord.x,
			startCoord.y,
			endCoord.x-startCoord.x,
			endCoord.y-startCoord.y
		);
	}
	#region 2D Utilities
	/// <summary>
	/// Reflects the direction away from the outer bounds(of main camera)
	/// </summary>
	/// <param name="_position">Position.</param>
	/// <param type="ref" name="_direction">Direction.</param>
	public static void Reflect(Vector3 _position,ref Vector3 _direction)
    {
        Vector2 reflectDir = Vector2.zero;
		if(_position.x <= cameraRect.xMin|| _position.x >= cameraRect.xMax)
		{
            reflectDir += Vector2.Reflect(_direction,Vector2.right);
		}
		if(_position.y <= cameraRect.yMin || _position.y >= cameraRect.yMax)
		{
            reflectDir += Vector2.Reflect(_direction, Vector2.up);
        }
        if (reflectDir != Vector2.zero)
        {
            _direction = reflectDir;
        }
        _direction.Normalize();
    }
	/// <summary>
    /// Keeps the GameObject on the screen
    /// </summary>
    /// <param name="_position">position of the GameObject</param>
    /// <param name="_spritescale">the SpriteRenderer size of the gameobject</param>
    /// <return>returns a new position preventing the Gameobject from going out of bounds</return>
	public static Vector3 KeepOnScreenData(Vector3 _position,Vector3 _spritescale)
	{
		if(_position.x < cameraRect.xMin + _spritescale.x)
		{
			_position.x = cameraRect.xMin + _spritescale.x;
		}
		if(_position.x > cameraRect.xMax - _spritescale.x)
		{
            _position.x = cameraRect.xMax - _spritescale.x;
		}
		if(_position.y < cameraRect.yMin + _spritescale.y)
		{
            _position.y = cameraRect.yMin + _spritescale.y;
		}
		if(_position.y > cameraRect.yMax - _spritescale.y)
        {
            _position.y = cameraRect.yMax - _spritescale.y;
        }
        return _position;
	}
	/// <summary>
    /// Determines if position is offscreen
    /// </summary>
    /// <param name="_position">the position of the GameObject</param>
    /// <param name="_spritesize">the SpriteRenderer size for the GameObject</param>
    /// <returns>returns true if GameObject is outside of camera rect</returns>
	public static bool IsOffScreen(Vector3 _position, Vector3 _spritesize){
        return _position.x < cameraRect.xMin + _spritesize.x || _position.x > cameraRect.xMax - _spritesize.x || 
                        _position.y < cameraRect.yMin + _spritesize.y || _position.y > cameraRect.yMax - _spritesize.y;
    }
	#endregion
}