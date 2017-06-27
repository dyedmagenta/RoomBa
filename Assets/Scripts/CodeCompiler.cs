using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UCompile;
using UnityEngine;
using UnityEngine.UI;
public class CodeCompiler : MonoBehaviour
{
    public InputField Input;
    public TMP_InputField Output;
    public GameObject Roomba;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCompileAddComponentClick()
    {
        if (Input == null) return;
        var codeText = Input.text;
        var engine = new UCompile.CSScriptEngine();
        engine.AddUsings("using UnityEngine;");
        engine.CompileType("UserCode", codeText);

        IScript result = engine.CompileCode(@"
        ");
    }

    public void OnCompileClick()
    {
        if (Input == null) return;
        var codeText = Input.text;
        var engine = new UCompile.CSScriptEngine();
        engine.AddUsings("using UnityEngine;");
        engine.AddOnCompilationFailedHandler(OnCompilationFailed);
        engine.AddOnCompilationSucceededHandler(OnCompilationSucceded);
        var result = engine.CompileCode(codeText);
       
        Debug.Log(codeText);
        if (result == null) return;
        result.Execute();
        Debug.Log("OnCompileClick()");
    }

    private void OnCompilationSucceded(CompilerOutput obj)
    {
        Debug.Log("OnCompilationSucceded()");
        foreach (var warning in obj.Warnings)
        {
            for (var i = 0; i < obj.Warnings.Count; i++)
            {
                //var output = "<color=#ffa500ff>" + warning + "</color></br>";
                Output.text += obj.Warnings[i] + Environment.NewLine;
            }
        }
    }

    private void showLog()
    {
        Debug.Log("stest");
    }
    private void OnCompilationFailed(CompilerOutput obj)
    {
        Debug.Log("OnCompilationFailed() => " + obj.Errors.ToString() + " => " + obj.Warnings);
        for (var i = 0; i < obj.Errors.Count; i++)
        {
            var output = "<color=#ff0000ff>" + obj.Errors[i] + "</color></br>";
            Debug.Log(output);
            Output.text += obj.Errors[i] + Environment.NewLine;
        }
        //        foreach (var error in obj.Errors)
        //        {
        //          
        //        }

        for (var i = 0; i < obj.Warnings.Count; i++)
        {
            //var output = "<color=#ffa500ff>" + warning + "</color></br>";
            Output.text += obj.Warnings[i] + Environment.NewLine;
        }
    }
}