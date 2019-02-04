

from UnityEngine import *
import sys

sys.path.append(r'C:\Users\darwo\Desktop\internship-workspace\Python workspace\venv\Lib\site-packages')
sys.path.append(r'C:\Program Files\IronPython 2.7\Lib')



Debug.Log("Hello world from Python!")

filePathToSprite = "../Sprites/"

fileName = "test.png"


scene = SceneManagement.SceneManager.GetActiveScene()

Debug.Log(scene.path)

Car = GameObject.Find("Car")

#Car.Destroy(Car)


os.rename("../Sprites/test.png","test2.png")

def testFunc(var1, var2):
    result = var1 + var2

    return result