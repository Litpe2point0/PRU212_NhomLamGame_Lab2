using UnityEngine;

public class FlipScore : MonoBehaviour
{
    [SerializeField] private float baseFlipScore = 100f; // Base score for one flip
    private float lastRotationZ;
    private float accumulatedRotation = 0f;
    private int flipCount = 0;
    private bool isAirborne = false;

    private ScoreKeeper scoreKeeper;
    private UIDisplay uiDisplay;
    private Rigidbody2D rb;

    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        uiDisplay = FindFirstObjectByType<UIDisplay>();
        rb = GetComponent<Rigidbody2D>(); // Assuming the player has a Rigidbody2D
    }

    private void Update()
    {
        DetectAirborneState(); // Update whether the player is in the air

        float currentRotationZ = transform.eulerAngles.z;
        float rotationDifference = Mathf.DeltaAngle(lastRotationZ, currentRotationZ);

        if (isAirborne)
        {
            accumulatedRotation += rotationDifference;

            // Check if a full 360� flip is completed
            if (Mathf.Abs(accumulatedRotation) >= 270f)
            {
                flipCount++; // Increase flip counter

                // Apply increasing score multiplier (1.15x per extra flip)
                float scoreToAdd = baseFlipScore + 50f * (flipCount - 1);
                scoreKeeper.ModifyScore(Mathf.RoundToInt(scoreToAdd));
                uiDisplay.ShowPoint(Mathf.RoundToInt(scoreToAdd));

                accumulatedRotation = 0f; // Reset rotation accumulation
            }
        }

        lastRotationZ = currentRotationZ; // Update last known rotation
    }

    private void DetectAirborneState()
    {
        // Example check: Consider player airborne if velocity.y is above a threshold
        isAirborne = Mathf.Abs(rb.linearVelocity.y) > 0.1f;

        // Reset flip tracking when landing
        if (!isAirborne)
        {
            accumulatedRotation = 0f;
            flipCount = 0;
        }
    }
}
