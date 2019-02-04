﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IronPython.Hosting;




public class runPythonScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
           
        


    }


    public void runPythonStyleTransfer()
    {
        Debug.Log("started runPythonscript.cs");

        var engine = global::UnityPython.CreateEngine();


        ICollection<string> searchPaths = engine.GetSearchPaths();


        searchPaths.Add(@"C:\Users\darwo\Desktop\internship-workspace\Python workspace\venv\Lib\site-packages");

        searchPaths.Add(@"C:\Users\darwo\Desktop\driving_simulator_repo\group_project\SOC09109_group_project\Assets\Plugins\Python\Lib");


        engine.SetSearchPaths(searchPaths);

        foreach (string path in engine.GetSearchPaths())
        {
            Debug.Log(path);
        }


        var scope = engine.CreateScope();


        var source = engine.ExecuteFile("Assets /Scripts/Neural Network/changeImage.py", scope);


        dynamic test = scope.GetVariable("testFunc");

        var result = test(3, 4);

        Debug.Log(result);

    }

    public void runTensorFlowSharp()
    {
       
           

        
        /*
        //Testing if tensor flow works
        using (var session = new TFSession())
        {
            var graph = session.Graph;

            var a = graph.Const(2);
            var b = graph.Const(3);
            Debug.Log("a = 2 b = 3");

            // Add two constants
            var addingResults = session.GetRunner().Run(graph.Add(a, b));
            var addingResultValue = addingResults.GetValue();
            Debug.Log("a+b= " + addingResultValue);

            // Multiply two constants
            var multiplyResults = session.GetRunner().Run(graph.Mul(a, b));
            var multiplyResultValue = multiplyResults.GetValue();
            Debug.Log("a*b= " + multiplyResultValue);


            
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
