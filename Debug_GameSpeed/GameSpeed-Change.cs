
// Pause the Ediotr
if(Input.GetKeyDown(KeyCode.H))
	EditorApplication.isPlaying = false;

// Change Speed
if(Input.GetKeyDown(KeyCode.L))
    GameController.Instance.gameTime = Mathf.Min(5f, GameController.Instance.gameTime + 0.25f);
else if (Input.GetKeyDown(KeyCode.K))
    GameController.Instance.gameTime = 1f;
else if (Input.GetKeyDown(KeyCode.J))
    GameController.Instance.gameTime = Mathf.Max(0f, GameController.Instance.gameTime - 0.25f);