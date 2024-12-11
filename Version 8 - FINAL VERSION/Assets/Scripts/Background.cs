using UnityEngine;

public class Background : MonoBehaviour {

    public float speed = 5f; //Speed of the background movement
    public GameObject[] backgrounds; //Array to store the background objects
    private Player playerControl; //Refer to player class
    private float backgroundWidth; //Width of a single background
    public int soulSpeedIncrease = 5; //Number of souls needed to increase background speed
    public float speedIncrement = 0.5f; //Increase the speed of the background by 2 for every 5 souls collected

    void Start() {
    
        //Get width of the background from first backgrounds collider
        backgroundWidth = backgrounds[0].GetComponent<BoxCollider>().size.x;

        //Get reference to the PlayerController to check the game over state
        playerControl = GameObject.FindWithTag("Player").GetComponent<Player>();

        //Set initial positions of the backgrounds
        ArrangeBackgrounds();
    }

    void Update() {

        //Move all backgrounds to the left if the game is not over
        if (playerControl.isGameOver){
         
        }
        else {
            // Check for soul count to increase difficulty
            if (playerControl.GetSoulCount() >= soulSpeedIncrease) {
                IncreaseDifficulty();
            }

            //Loop to move each background to the left
            for (int i = 0; i < backgrounds.Length; i++) {
                backgrounds[i].transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            }
        }

        //Check if any of the backgrounds have gone off screen, reset if they have
        for (int i = 0; i < backgrounds.Length; i++) {
            if (backgrounds[i].transform.position.x < -backgroundWidth) {
            
                //Move the background to the right end 
                RepositionBackground(backgrounds[i]);
            }
        }
    }

    //Helper method to reposition a background when it goes off screen
    void RepositionBackground(GameObject background) {
    
        //Find the rightmost background and place the current background right after it
        float rightMostPosition = getFurthestBackground();
        background.transform.position = new Vector3(rightMostPosition + backgroundWidth, background.transform.position.y, background.transform.position.z);
    }

    //Helper method to find the rightmost background position
    float getFurthestBackground() {
    
        float rightMostPosition = backgrounds[0].transform.position.x;
        for (int i = 0; i < backgrounds.Length; i++) {
        
            if (backgrounds[i].transform.position.x > rightMostPosition) {
            
                rightMostPosition = backgrounds[i].transform.position.x;
            }
        }
        return rightMostPosition;
    }

    //Helper method to arrange the backgrounds initially
    void ArrangeBackgrounds() {
    
        //Place each background right next to each other
        float Offset = 0;
        for (int i = 0; i < backgrounds.Length; i++) {
        
            backgrounds[i].transform.position = new Vector3(Offset, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);

            //Offset each background by its width
            Offset += backgroundWidth;  
        }
    }

    void IncreaseDifficulty() {

        speed += speedIncrement;
        soulSpeedIncrease += 5;
    }
}