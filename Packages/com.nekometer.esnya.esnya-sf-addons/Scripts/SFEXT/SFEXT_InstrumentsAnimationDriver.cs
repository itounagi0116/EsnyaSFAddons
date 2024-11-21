using System;
using JetBrains.Annotations;
using SaccFlightAndVehicles;
using UdonSharp;
using UdonToolkit;
using UnityEngine;
using VRC.Udon;

namespace EsnyaSFAddons.SFEXT
{
    /// <summary>
    /// Drive animation parameters of flight instruments.
    /// </summary>
    [UdonBehaviourSyncMode(BehaviourSyncMode.None)]
    public class SFEXT_InstrumentsAnimationDriver : UdonSharpBehaviour
    {
        /// <summary>
        /// Animator to drive.
        ///
        /// Use airVehicle.VehicleAnimator if null
        /// </summary>
        [CanBeNull] public Animator instrumentsAnimator;

        /// <summary>
        /// Response of vacuum power witch driven by engine
        /// </summary>
        public float vacuumPowerResponse = 1.0f;

        /// <summary>
        /// Battery bus state.
        ///
        /// Always on if null.
        /// </summary>
        [CanBeNull] public GameObject batteryBus;

        /// <summary>
        /// Response of battery voltage.
        /// </summary>
        public float batteryVoltageResponse = 1.0f;

        /// <summary>
        /// Magnetic declination.
        /// </summary>
        public float magneticDeclination;

        /// <summary>
        /// Response of velocity indicators.
        /// </summary>
        public float smoothedVelocityResponse = 0.25f;

        [Header("ADI")]
        /// <summary>
        /// Set true to enable Attitude Indicator.
        /// </summary>
        public bool hasADI = true;

        /// <summary>
        /// Is electirc driven.
        /// </summary>
        [HideIf("@!hasADI")] public bool adiElectric = false;

        /// <summary>
        /// Max pitch angle in degrees.
        /// </summary>
        [HideIf("@!hasADI")] public float maxPitch = 30;

        /// <summary>
        /// Name of parameter in animator.
        ///
        /// -maxPitch to maxPitch will be remapped to 0.0 to 1.0.
        /// </summary>
        [NotNull][HideIf("@!hasADI")] public string pithFloatParameter = "pitch";


        /// <summary>
        /// Name of parameter in animator.
        ///
        /// -180 to 180 degrees will be remapped to 0.0 to 1.0.
        /// </summary>
        [NotNull][HideIf("@!hasADI")] public string rollFloatParameter = "roll";

        [Header("HI")]
        /// <summary>
        /// Set true to enable Heading Indicator.
        /// </summary>
        public bool hasHI = true;

        /// <summary>
        /// Is electirc driven.
        /// </summary>
        [NotNull][HideIf("@!hasHI")] public bool hiElectric = false;

        /// <summary>
        /// Name of parameter in animator.
        ///
        /// 0 to 360 degrees will be remapped to 0.0 to 1.0.
        /// </summary>
        [NotNull][HideIf("@!hasHI")] public string headingFloatParameter = "heading";

        [Header("ASI")]
        /// <summary>
        /// Set true to enable Airspeed Indicator.
        /// </summary>
        public bool hasASI = true;

        /// <summary>
        /// Max indicated airspeed in knots.
        /// </summary>
        [HideIf("@!hasASI")] public float maxAirspeed = 180.0f;

        /// <summary>
        /// Response of airspeed indicator.
        /// </summary>
        [HideIf("@!hasASI")] public float asiResponse = 0.25f;

        /// <summary>
        /// Name of parameter in animator.
        ///
        /// 0 to maxAirspeed will be remapped to 0.0 to 1.0.
        /// </summary>
        [NotNull][HideIf("@!hasASI")] public string airspeedFloatParameter = "airspeed";

        [Header("Altimeter")]
        /// <summary>
        /// Set true to enable barometric Altimeter.
        /// </summary>
        public bool hasAltimeter = true;
        /// <summary>
        /// Max indicated altitude in feet.
        /// </summary>
        [HideIf("@!hasAltimeter")] public float maxAltitude = 20000;

        /// <summary>
        /// Response of altimeter.
        /// </summary>
        [HideIf("@!hasAltimeter")] public float altimeterResponse = 0.25f;

        /// <summary>
        /// Name of parameter in animator.
        ///
        /// 0 to maxAltitude will be remapped to 0.0 to 1.0.
        /// </summary>
        [NotNull][HideIf("@!hasAltimeter")] public string altitudeFloatParameter = "altitude";

        [Header("TC")]
        /// <summary>
        /// Set true to enable Turn Coordinator
        /// </summary>
        public bool hasTC = true;

        /// <summary>
        /// Is turn coordinator electric.
        /// </summary>
        [HideIf("@!hasTC")] public bool tcElectric = true;

        /// <summary>
        /// Max turn rate.
        /// </summary>
        [HideIf("@!hasTC")] public float maxTurn = 360.0f / 60.0f * 2.0f;

        /// <summary>
        /// Response of turn coordinator.
        /// </summary>
        [HideIf("@!hasTC")] public float turnResponse = 1.0f;

        /// <summary>
        /// Name of parameter in animator.
        ///
        /// -maxTurn to maxTurn will be remapped to 0.0 to 1.0.
        /// </summary>
        [NotNull][HideIf("@!hasTC")] public string turnRateFloatParameter = "turnrate";

        [Header("SI")]
        /// <summary>
        /// Set true to enable Slip Indicator ("Ball").
        /// </summary>
        public bool hasSI = true;

        /// <summary>
        /// Max slip angle in degrees.
        /// </summary>
        [HideIf("@!hasSI")] public float maxSlip = 12.0f;

        /// <summary>
        /// Response of slip indicator.
        /// </summary>
        [HideIf("@!hasSI")] public float slipResponse = 0.2f;

        /// <summary>
        /// Name of parameter in animator.
        ///
        /// -maxSlip to maxSlip will be remapped to 0.0 to 1.0.
        /// </summary>
        [NotNull][HideIf("@!hasSI")] public string slipAngleFloatParameter = "slipangle";

        [Header("VSI")]
        /// <summary>
        /// Set true to enable Vertical Speed Indicator.
        /// </summary>
        public bool hasVSI = true;

        /// <summary>
        /// Max indicated vertical speed in feet per minute.
        /// </summary>
        [HideIf("@!hasVSI")] public float maxVerticalSpeed = 2000;

        /// <summary>
        /// Response of vertical speed indicator.
        /// </summary>
        [HideIf("@!hasVSI")] public float vsiResponse = 0.25f;

        /// <summary>
        /// Name of parameter in animator.
        ///
        /// -maxVerticalSpeed to maxVerticalSpeed will be remapped to 0.0 to 1.0.
        /// </summary>
        [NotNull][HideIf("@!hasVSI")] public string verticalSpeedFloatParameter = "vs";

        [Header("Magnetic Compass")]
        /// <summary>
        /// Set true to enable standby magnetic compass.
        /// </summary>
        public bool hasMagneticCompass = true;

        /// <summary>
        /// Response of magnetic compass
        /// </summary>
        [HideIf("@hasMagneticCompass")] public float compassResponse = 0.5f;

        /// <summary>
        /// Name of parameter in animator
        ///
        /// 0 to 360 degrees will be remapped to 0.0 to 1.0.
        /// </summary>
        [NotNull][HideIf("@!hasMagneticCompass")] public string magneticCompassFloatParameter = "compass";


        [Header("Clock")]
        /// <summary>
        /// Set true to enable Clock
        /// </summary>
        public bool hasClock = true;

        /// <summary>
        /// Set true to show local time.
        /// </summary>
        [HideIf("@!hasClock")] public bool localTime;

        /// <summary>
        /// Name of parameter for animator.
        ///
        /// 00:00:00 to 24:00:00 will be
