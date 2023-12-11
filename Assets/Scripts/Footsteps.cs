using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{

    private enum CURRENT_TERRAIN { LEVEL, ROAD, GROUND, WATER };

    [SerializeField]
    private CURRENT_TERRAIN currentTerrain;

    private FMOD.Studio.EventInstance foosteps;

    private void Update()
    {
        DetermineTerrain();
    }

    private void DetermineTerrain()
    {
        RaycastHit[] hit;

        hit = Physics.RaycastAll(transform.position, Vector3.down, 10.0f);

        foreach (RaycastHit rayhit in hit)
        {
            if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Road"))
            {
                currentTerrain = CURRENT_TERRAIN.ROAD;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                currentTerrain = CURRENT_TERRAIN.GROUND;
                break;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Level"))
            {
                currentTerrain = CURRENT_TERRAIN.LEVEL;
            }
            else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Water"))
            {
                currentTerrain = CURRENT_TERRAIN.WATER;
            }
        }
    }

    public void SelectAndPlayFootstep()
    {
        switch (currentTerrain)
        {
            case CURRENT_TERRAIN.ROAD:
                PlayFootstep(1);
                break;

            case CURRENT_TERRAIN.LEVEL:
                PlayFootstep(0);
                break;

            case CURRENT_TERRAIN.GROUND:
                PlayFootstep(2);
                break;

            case CURRENT_TERRAIN.WATER:
                PlayFootstep(3);
                break;

            default:
                PlayFootstep(0);
                break;
        }
    }

    private void PlayFootstep(int terrain)
    {
        foosteps = FMODUnity.RuntimeManager.CreateInstance("event:/Footsteps");
        foosteps.setParameterByName("Terrain", terrain);
        foosteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        foosteps.start();
        foosteps.release();
    }
}