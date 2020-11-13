using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerAnimation : MonoBehaviour
{

    public List<GameObject> models = new List<GameObject>();
    
    Animator anim;
    GameObject currentModel = null;

    public Animator GetAnimator() { return anim; }

    public void ChangeModel(int _model)
    {
        if (currentModel != null)
        {
            currentModel.SetActive(false);
            models[_model].SetActive(true);
        }
        models[_model].SetActive(true);
        anim = models[_model].GetComponent<Animator>();
    }

}
