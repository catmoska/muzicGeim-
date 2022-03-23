using UnityEngine.SceneManagement;

public static class SenMenedgersic
{
    private static int levis = 3;
    public static void levelUp()
    {
        if(levis-1 <= SceneManager.GetActiveScene().buildIndex)
            res();
        else
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void res()
    {
        SceneManager.LoadScene(0);
    }
}
