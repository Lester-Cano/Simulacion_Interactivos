using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAsistant : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]private ParticleSystem ps;
    [SerializeField] private WindZone wind;
    void Start()
    {
    // Crear un color personalizado con RGB
        Color starColor = new Color(0.5f, 0.2f, 0.8f); // Valores de rojo, verde y azul respectivamente
    // Obtener el componente ParticleSystem del objeto
        ParticleSystem ps = GetComponent<ParticleSystem>();

    // Obtener el módulo Main del sistema de partículas
        ParticleSystem.MainModule mainModule = ps.main;

    // Cambiar el color de las partículas al color personalizado
        mainModule.startColor = starColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (wind.windMain > 0)
        {
            Color hotColor = new Color(1f, 0.5f, 0.2f); // Valores de rojo, verde y azul respectivamente
            ParticleSystem.MainModule mainModule = ps.main;
            mainModule.startColor = hotColor;
        }
        else if (wind.windMain == 0)
        {
            Color zeroColor = new Color(1f, 1f, 1f); // Valores de rojo, verde y azul respectivamente
            ParticleSystem.MainModule mainModule = ps.main;
            mainModule.startColor = zeroColor;
        }
        else
        {
            Color coldColor = new Color(0.2f, 0.8f, 1f); // Valores de rojo, verde y azul respectivamente
            ParticleSystem.MainModule mainModule = ps.main;
            mainModule.startColor = coldColor;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            wind.windMain = 0;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            wind.windMain = 10;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            wind.windMain = -10;
        }
    }
}
