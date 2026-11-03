using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class SpawnSequence : MonoBehaviour {
    bool AnimationComplete(Animator anim) {
        var info = anim.GetCurrentAnimatorStateInfo(0);
        return info.normalizedTime >= 1f;
    }
    public Transform character;
    public Transform targetPosition;
    public Animator capsuleAnimator;
    public float speed = 2f;
    IEnumerator SpawnElonl() {
        capsuleAnimator.Play("CapsuleAnimation");
        yield return null;
        print("starting spawn sequence");
        while (!AnimationComplete(capsuleAnimator))
            yield return null;
     
        var t = targetPosition.position;
        while (character.position != t) {
            character.position = Vector3.MoveTowards(
                character.position,
                t,
                speed * Time.deltaTime);

            yield return null;
        }

        yield return new WaitForSeconds(1f);
        print("Giving control to player");
      
    }
    void Start() {
     
        Invoke("GameStart", 3f);
    }

    void GameStart() {
        StartCoroutine(SpawnElonl());
    }

    // Update is called once per frame
    void Update() {

    }
}
