

from UnityEngine import *


Debug.Log("Hello world from Python!")

filePathToSprite = "../Sprites/"

fileName = "test.png"


scene = SceneManagement.SceneManager.GetActiveScene()

Debug.Log(scene.path)


#os.rename("../Sprites/test.png","test2.png")

def testFunc(var1, var2):
    result = var1 + var2

    return result