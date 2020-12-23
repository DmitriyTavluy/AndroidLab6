using System.Collections;
using UnityEngine.Advertisements;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
    public static bool jump, nextBlock;
    public GameObject mainCube, lose_button, gameover;
    private bool animate, lose;
    private float scrath_speed = 0.5f, startTime, yPosCube;
    public static int count_blocks;

   void Start()
    {
        StartCoroutine(CanJump());
        jump = false;
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3942101", false);
        }
      
    }

    void FixedUpdate ()
    {
        if (animate && mainCube.transform.localScale.y > 0.4f)
        {
            PressCube(-scrath_speed);
            
        }else if (!animate && mainCube != null)
        {
            if (mainCube.transform.localScale.y < 1f) 
            {
                PressCube(scrath_speed * 5f);
               
            }else if (mainCube.transform.localScale.y != 1f)
                {
                    mainCube.transform.localScale = new Vector3(1f, 1f, 1f);
                }
        }

        if (mainCube != null)
        {
            if (mainCube.transform.position.y < -5f)
            {
                if (Advertisement.IsReady())
                {
                    Advertisement.Show("video");
                }
                Destroy(mainCube, 0.001f);
                print("Player Lose");
                lose = true;
            }
        }

        if (lose)
        {
            PlayerLose();
        }
    }

    void PlayerLose()
    {
        lose_button.gameObject.SetActive(true);
        gameover.gameObject.SetActive(true);
    }

    void OnMouseDown ()
    {

        if (nextBlock && mainCube.GetComponent <Rigidbody> ())
        {
            animate = true;
            startTime = Time.time;
            yPosCube = mainCube.transform.localPosition.y;
            

        }
    }

    void OnMouseUp ()
    {
        if (nextBlock && mainCube.GetComponent <Rigidbody> ())
        {
            animate = false;

            //Jump
            jump = true;
            float force, diff;
            diff = Time.time - startTime;
            if (diff < 3f)
                force = 190 * diff;
            else
                force = 300f;
            if (force < 60f)
                force = 60f;
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.up * force);
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * force);
            StartCoroutine(checkCubePos());
            nextBlock = false;
        }
    }

    void PressCube (float force)
    {
        mainCube.transform.localPosition += new Vector3(0f, force * Time.deltaTime, 0f);
        mainCube.transform.localScale += new Vector3(0f, force * Time.deltaTime, 0f);
    }

    IEnumerator checkCubePos()
    {
      yield return new WaitForSeconds(1f);
        if (yPosCube == mainCube.transform.localPosition.y)
        {
            print("Player Lose");
            lose = true;
        }
        else
        {

            while (!mainCube.GetComponent<Rigidbody>().IsSleeping())
            {
                yield return new WaitForSeconds(0.05f);
                if (mainCube == null)
                    break;
            }
            if (!lose)
            {
                nextBlock = true;
                print("Next One");
                count_blocks++;
                mainCube.transform.localPosition = new Vector3(mainCube.transform.localPosition.x, mainCube.transform.localPosition.y, -0.31f);
              
                mainCube.transform.eulerAngles = new Vector3(0f, mainCube.transform.eulerAngles.y, 0f);
            }
        }


    }

    IEnumerator CanJump()
    {
        while (!mainCube.GetComponent<Rigidbody>())
            yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(0.2f);
        nextBlock = true;
    }
}
