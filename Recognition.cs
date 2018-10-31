using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
public class Recognition : MonoBehaviour {

    KeywordRecognizer keyrecognizer; //Creates a keyrecognizer
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();


    // Use this for initialization
    void Start()
    {

        keywords.Add("Go", () =>
        {
            GoCalled();
        });

        keyrecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keyrecognizer.OnPhraseRecognized += keywordRecogOnPhrase;

        keyrecognizer.Start();
    }

    void keywordRecogOnPhrase(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        if(keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }

    void GoCalled()
    {
        print("You called Go!");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
