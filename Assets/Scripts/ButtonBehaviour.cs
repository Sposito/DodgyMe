using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour {
    public enum ButtonKind {None, Retry, Continue, Start};
    public ButtonKind kind = ButtonKind.None;
    Color color;
    MeshRenderer rend;
    bool justEntered = true;

	void Start () {
        rend = GetComponent<MeshRenderer>();
        color = rend.material.color;

	}

    void OnMouseOver(){
        if (justEntered) {
            rend.material.color = Color.Lerp(color, Color.white, 0.3f);
            justEntered = false;
			print(9);
        }

        if(Input.GetMouseButton(0)){
            switch (kind){
                case ButtonKind.Retry:
					LevelController.SubmitScore();
					//Reset Score
					LevelController.Score = 0;
                    LevelController.isDisplayingMenu = false;
                    LevelController.isRetrying = true;
                    SceneManager.LoadScene(0);
                    break;
                case ButtonKind.Continue:
                    LevelController.singleton.ContinueGame();
                    break;
                case ButtonKind.Start:
                    LevelController.singleton.StartGame();
                    break;
                default:
                    break;
            }

        }
       
    }

    void OnMouseExit(){
        justEntered = true;
        rend.material.color = color;
    }

}
