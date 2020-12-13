using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTextureMenu : MonoBehaviour
{
    public RawImage playerImage;

    private PlayerTextureSelector selector;

    void Start()
    {
        selector = GetComponent<PlayerTextureSelector>();
        AssignTexture();
    }

    private void AssignTexture()
    {
        var texture = selector.SelectedTexture;
        playerImage.texture = texture;
    }

    public void RightButton()
    {
        selector.NextTexture();
        AssignTexture();
    }
}
