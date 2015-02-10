using UnityEngine;
using System.Collections;
using UnityEditor;
public class RenderCubemap : ScriptableWizard {
    	// Render scene from a given point into a static cube map.
	// Place this script in Editor folder of your project.
	// Then use the cubemap with one of Reflective shaders!
		public Transform renderFromPosition;
		public Cubemap cubemap;
		
		public void OnWizardUpdate () {
			helpString = "Select transform to render from and cubemap to render into";
			isValid = (renderFromPosition != null) && (cubemap != null);
		}
		
		public void OnWizardCreate () {
			// create temporary camera for rendering
			GameObject go = new GameObject( "CubemapCamera", typeof(Camera));
			// place it on the object
			go.transform.position = renderFromPosition.position;
			go.transform.rotation = Quaternion.identity;

			// render into cubemap		
			go.GetComponent<Camera>().RenderToCubemap( cubemap );
			
			// destroy temporary camera
			DestroyImmediate( go );
		}
		
		[MenuItem("GameObject/Render into Cubemap")]
		static void RenderCubemapNow () {
            ScriptableWizard.DisplayWizard<RenderCubemap>("Render cubemap", "Render!");
		}
	}
