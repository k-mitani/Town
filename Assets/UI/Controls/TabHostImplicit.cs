using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TabHostImplicit : MonoBehaviour
{
    private Button[] tabButtons;
    private Transform[] tabContents;
    
    [SerializeField] private int tabIndex = 0;
    public int TabIndex
    {
        get { return tabIndex; }
        set
        {
            tabIndex = value;
            for (int i = 0; i < tabContents.Length; i++)
            {
                tabContents[i].gameObject.SetActive(i == tabIndex);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        var children = Util.GetChildren(transform);

        // �^�u�{�^�����擾����B
        var tabButtonsParent = children.FirstOrDefault(c => c.name.Equals("Tabs"));
        if (tabButtonsParent == null) tabButtonsParent = children[0];
        tabButtons = tabButtonsParent.GetComponentsInChildren<Button>();

        // �^�u�R���e���g���擾����B
        tabContents = children.Except(new[] { tabButtonsParent }).ToArray();

        // �^�u�{�^���̃N���b�N�C�x���g��ݒ肷��B
        for (int i = 0; i < tabButtons.Length; i++)
        {
            var ii = i;
            tabButtons[i].onClick.AddListener(() => TabIndex = ii);
        }

        // �����^�u��\������B
        TabIndex = tabIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
