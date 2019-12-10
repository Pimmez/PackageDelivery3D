//Dit is een basis interface met simpelen methodes.
public interface IInput
{
	//Default
	void Movement();

	//DO WEB
	void WebMovement();

	//DO XBOX
	void ControllerMovement();

	//DO ANDROID
	void MobileMovement();
}