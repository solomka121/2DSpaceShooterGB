using UnityEngine;

public sealed class GunRotate : Gun
{
    private void Update()
    {
        RotateTowards(input.MousePosition);
    }
    public void RotateTowards(Vector2 position)
    {
        transform.up = position - new Vector2(transform.position.x, transform.position.y);
    }
}
