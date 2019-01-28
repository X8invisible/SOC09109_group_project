using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IronPython.Hosting;

public class runPythonScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
            Debug.Log("started runPythonscript.cs");

            var engine = Python.CreateEngine();
			var scope = engine.CreateScope();

			string code = "str = 'Hello world!'";

			var source = engine.CreateScriptSourceFromString(code);
			source.Execute(scope);

			Debug.Log(scope.GetVariable<string>("str"));


    }


    public void runPythonStyleTransfer()
    {
        //TODO
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
