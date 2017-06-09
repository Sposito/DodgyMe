/// <summary> </summary>
public class ChikenController : MobController {

	protected override void ChangeScore(){
		LevelController.Score--;
	}
}
