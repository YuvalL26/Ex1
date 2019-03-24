using System;
using System.Collections.Generic;

public class FunctionsContainer
{

    public delegate double FunctionPtr(double val);

    private Dictionary<string, FunctionPtr> dictFunc;

    public FunctionsContainer()
    {
        dictFunc = new Dictionary<string, FunctionPtr>();
    }

    /*
     * overload the operator[].
     */
    public FunctionPtr this[string key]
    {
        get
        {
            // if not exsit, add to dictionary
            if (!dictFunc.ContainsKey(key))
            {
                dictFunc.Add(key, val => val);
            }
            return dictFunc[key];
        }
        set
        {
            // if key is in the dictionary, regenerate his value. 
            if (!dictFunc.ContainsKey(key))
            {
                dictFunc.Add(key, value);
            }
            dictFunc[key] = value;
        }
    }

    /*
     this function returns the mission functions in a list
    */
    public List<string> getAllMissions()
    {
        List<string> allMissions = new List<string>();
        foreach (string name in dictFunc.Keys)
        {
            allMissions.Add(name);
        }
        return allMissions;
    }
}
