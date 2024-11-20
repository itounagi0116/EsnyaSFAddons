# Esnya SF Addons

[SaccFlightAndVehicles](https://github.com/Sacchan-VRC/SaccFlightAndVehicles)用のアドオンとユーティリティです。

[![GitHub license](https://img.shields.io/github/license/SeaeeesSan/SimpleFolderIcon)](https://github.com/SeaeeesSan/SimpleFolderIcon/blob/master/LICENSE)

---

## 必要要件
- [VRChat Creator Companion(VCC)](https://github.com/vrchat-community/creator-companion) 経由でインストールする [**UdonSharp 1.x**](https://github.com/vrchat-community/UdonSharp)  
- [**SaccFlightAndVehicles 1.63**](https://github.com/Sacchan-VRC/SaccFlightAndVehicles/tree/1.63)  
- [UdonToolkit](https://github.com/orels1/UdonToolkit/)  
- [InariUdon](https://github.com/esnya/InariUdon/)  

---

## インストール手順
1. 必要要件をすべてインストールしてください。  
2. Unityの「Package Manager」ウィンドウを開きます。  

![image](https://user-images.githubusercontent.com/2088693/217635380-a175d873-bf18-412e-bc74-2c7df1fe9b17.png)

3. 「Add package from git URL」をクリックします。  

![image](https://user-images.githubusercontent.com/2088693/217635570-44827dc0-cb20-4e4d-a4d3-7ef1e1041d6f.png)

4. 次のURLを入力し、「Add」をクリックします。  
   - 通常版: `git+https://github.com/esnya/EsnyaSFAddons.git?path=Packages/com.nekometer.esnya.esnya-sf-addons`  
   - ベータ版: `git+https://github.com/esnya/EsnyaSFAddons.git?path=Packages/com.nekometer.esnya.esnya-sf-addons#beta`

![image](https://user-images.githubusercontent.com/2088693/217635892-7a612e44-f09f-452c-9741-d981542fc412.png)

---

## 機能一覧
### カスタムインスペクター / ギズモ  
#### **SaccEntityEditor**  
![image](https://user-images.githubusercontent.com/2088693/148947722-70cbda93-6721-4722-b0c7-527bd5a32c38.png)  

**SaccEntity** 用のカスタムインスペクターです。検証機能や自動入力ボタンを備えています。  

![image](https://user-images.githubusercontent.com/2088693/148947839-bf8f137f-38dd-4faf-8d96-b9fffd6b6c99.png)  

以下のDFUNCやExtensionの参照を自動検索して入力します。また、以下の指定された名前のGameObjectも検索します：
- InVehicleOnly  
- HoldingOnly  
- CenterOfMass  
- SwitchFunctionSound  
- DisabledAfter10Seconds  

![image](https://user-images.githubusercontent.com/2088693/148948264-03c1996c-7864-45a8-bc33-305bf76e154e.png)  

**StickDisplay** のMFDアイテムを自動的に整列します。
- 親GameObjectの名前は「StickDisplayL」または「StickDisplayR」である必要があります。Templateフォルダ内のプレハブの使用を推奨します。
- 各アイテムの名前は「MFD_」で始まる必要があります。

#### **SAV_KeyboardControlsEditor**  
![image](https://user-images.githubusercontent.com/2088693/142752033-5c491832-0b28-4bf2-9317-dae26314fe8e.png)  

**SAV_KeyboardControls** 用のカスタムインスペクターで、自動入力ボタンを備えています。

#### **SVGizmoDrawer**  
![image](https://user-images.githubusercontent.com/2088693/142752067-16101550-75a2-4800-bca4-51fd82704d39.png)  

**SaccVehicleSeat** の **TargetEyeHeight** や **FloatScript** の **FloatPoints** にギズモを追加します。

---

### Udonスクリプト
#### **SFRuntimeSetup**  
![image](https://user-images.githubusercontent.com/2088693/142752139-16044ef1-ca37-40ce-b437-f3d3f4cec1c8.png)  

ワールドに設定されたパラメータをPrefabを上書きせずに、ワールド読み込み時にすべての車両に適用します。

---

## SFUdonChips

**SaccFlight** を **UdonChips** と統合するアドオンです。

#### **SAV_UdonChips**  
![image](https://user-images.githubusercontent.com/2088693/142752173-58ba708d-1f6f-4f80-9457-b394f02baa47.png)

---

### SFUdonChips の必要要件
- [UdonChips-fork](https://github.com/esnya/UdonChips-fork)

---

### インストール手順
1. 必要要件をすべてインストールしてください。  
2. Unityの「Package Manager」ウィンドウを開きます。  
3. 「Add package from git URL」をクリックします。  
4. 次のURLを入力し、「Add」をクリックします：  
   `git+https://github.com/esnya/EsnyaSFAddons.git?path=Packages/com.nekometer.esnya.esnya-sf-addons-ucs`

---

### 追加資料(整備中)
以下に、 **このスクリプトの機能** の簡単な説明を追加しています(LLMを用いて作成している為その点はご留意下さい)

#### **1. 仮想通貨管理システム**
| **スクリプト名**               | **説明**                     |
|-------------------------------|-----------------------------|
| `GetMoneyOnExplode.cs`        | 爆発時に仮想通貨を加算する。   |
| `SFEXT_UdonChips.cs`          | 仮想通貨（UdonChips）の管理を行う。 |

#### **2. エディタ拡張（Editor関連）**
| **スクリプト名**                          | **説明**                                 |
|------------------------------------------|-----------------------------------------|
| `ESFADebugTools.cs`                      | デバッグツール。オブジェクト固定操作などを提供。 |
| `ESFAMenu.cs`                            | メニューにカスタム機能を追加。            |
| `ESFAUI.cs`                              | UI関連の補助機能を提供。                  |
| `SAV_KeyboardControlsEditor.cs`          | キーボード操作用カスタムエディタ。         |
| `SAV_PassengerFunctionsControllerEditor.cs` | 乗客用関数のカスタムエディタ。             |
| `SaccEntityEditor.cs`                    | エンティティ編集や検証ツール。             |
| `SFEditorUtility.cs`                     | エディタ用ユーティリティ。                 |
| `SFGizmoDrawer.cs`                       | ギズモ描画（視覚的デバッグ）を提供。        |

#### **3. アクセサリ関連**
| **スクリプト名**               | **説明**                                    |
|-------------------------------|--------------------------------------------|
| `CatapultController.cs`       | カタパルトの動作を制御。                      |
| `DrogueHead.cs`               | ドローグシュートの操作を管理。                 |
| `GroundWindIndicator.cs`      | 地上の風向指示器を制御。                      |
| `PickupChock.cs`              | 航空機の車輪止めを制御。                      |
| `RemoteThrottle.cs`           | リモートスロットルを操作可能にする。           |
| `WheelDriver.cs`              | 車輪駆動システムを制御。                      |
| `WheelLock.cs`                | 車輪ロック機構を提供。                        |
| `Windsock.cs`                 | 風向きを表示する吹流しを制御。                 |

#### **4. 航空機システム（Avionics）**
| **スクリプト名**               | **説明**                                    |
|-------------------------------|--------------------------------------------|
| `AuralWarnings.cs`            | 音声警告システムを提供。                     |
| `GPWS.cs`                     | 地上接近警報システムを制御。                  |
| `WindIndicator.cs`            | 風向指示器を制御。                           |

#### **5. ダイヤル操作（DFUNC）**
| **スクリプト名**                        | **説明**                                 |
|-----------------------------------------|-----------------------------------------|
| `DFUNCP_IHaveControl.cs`                | 操縦権限の設定管理。                     |
| `DFUNC_AdvancedCatapult.cs`             | 高度なカタパルト操作を提供。              |
| `DFUNC_AdvancedFlaps.cs`                | 高度なフラップ操作を提供。                |
| `DFUNC_AdvancedParkingBrake.cs`         | 高度な駐車ブレーキ制御。                  |
| `DFUNC_AdvancedSpeedBrake.cs`           | 高度なスピードブレーキ制御。              |
| `DFUNC_AdvancedThrustReverser.cs`       | 高度なスラストリバーサー制御。            |
| `DFUNC_AdvancedWaterRudder.cs`          | 高度な水上舵制御。                        |
| `DFUNC_AutoStarter.cs`                  | 自動エンジンスタート機能。                |
| `DFUNC_LandingLight.cs`                 | 着陸灯の制御を提供。                      |
| `DFUNC_SeatAdjuster.cs`                 | 座席調整機能を提供。                      |

#### **6. 気象関連（Weather）**
| **スクリプト名**              | **説明**                             |
|------------------------------|-------------------------------------|
| `FogController.cs`           | 霧の強度を制御。                     |
| `RVR_Controller.cs`          | 滑走路視距離（RVR）を制御。            |
| `RandomWindChanger.cs`       | ランダムな風向や風速を提供。           |

#### **7. 空中給油システム**
| **スクリプト名**               | **説明**                                             |
|-------------------------------|---------------------------------------------------|
| `RefuelingProbeController.cs` | 空中給油プローブの展開と接続を制御。                   |
| `RefuelingReceiver.cs`        | 給油時の燃料受け取りを管理。                         |
| `AdvancedTankerLogic.cs`      | 空中給油システムを補完する高度なロジックを提供。        |
| `TankerWaypointController.cs` | 空中給油機の移動パターンやウェイポイントを制御。        |

#### **8. カタパルト/着艦システム**
| **スクリプト名**               | **説明**                                             |
|-------------------------------|---------------------------------------------------|
| `CatapultController.cs`       | 高度なカタパルト操作とトリガー管理を提供。           |
| `ArrestingCableController.cs` | 着艦用ケーブルの展開と動作を制御。                   |
| `CatapultReadySignal.cs`      | 発射準備完了のシグナル表示を制御。                   |

#### **9. アクセサリ関連（高度な機能）**
| **スクリプト名**                  | **説明**                                  |
|----------------------------------|------------------------------------------|
| `AdvancedWheelLock.cs`           | 車輪ロックの高度な制御を提供。              |
| `DynamicWingFoldController.cs`   | 可動翼の折りたたみ制御（空母運用を想定）。   |
| `AirRefuelingHUD.cs`             | 空中給油用のHUDインジケーターを提供。        |

---

| **エスニアSFアドオン スクリプト名**      | **Inari依存関係**                                         | **Toolkit依存関係**                                       |
|----------------------------------------|---------------------------------------------------------|---------------------------------------------------------|
| **UI関連**                             |                                                         |                                                         |
| ESFAUI.cs                              | `MultiTextLoader` (Inari)                               |                                                         |
| UniversalTracker.cs                    |                                                         | `UniversalTracker` (Toolkit)                            |
| UniversalAction.cs                     |                                                         | `InteractTrigger`, `AreaTrigger` (Toolkit)              |
| **フォグ・環境制御**                   |                                                         |                                                         |
| FogController.cs                       |                                                         | `FogAdjustment` (Toolkit)                               |
| RVR_Controller.cs                      |                                                         |                                                         |
| **トリガー関連**                       |                                                         |                                                         |
| AreaTrigger.cs                         |                                                         | `AreaTrigger` (Toolkit)                                 |
| InteractTrigger.cs                     |                                                         | `InteractTrigger` (Toolkit)                             |
| PlatformTrigger.cs                     |                                                         | `PlatformTrigger` (Toolkit)                             |
| RespawnTrigger.cs                      |                                                         | `RespawnTrigger` (Toolkit)                              |
| **プレイヤー操作**                     |                                                         |                                                         |
| PlayerMovementModifier.cs              |                                                         | `PlayerMovementModifier` (Toolkit)                      |
| LerpedFollower.cs                      |                                                         | `LerpedFollower` (Toolkit)                              |
| **アニメーション**                     |                                                         |                                                         |
| ClockDriver.cs                         | `ClockAnimationStarter` (Inari)                         |                                                         |
| AnimatorDriver.cs                      | `AnimatorDriver` (Inari)                                |                                                         |
| **画像・素材制御**                     |                                                         |                                                         |
| ShaderFeeder.cs                        |                                                         |                                                         |
| AbstractImageDownloader.cs             | `AbstractImageDownloader`, `MultiImageDownloader` (Inari)|                                                         |
| **ネットワーク関連**                   |                                                         |                                                         |
| NetworkedTrigger.cs                    |                                                         | `NetworkedTrigger` (Toolkit)                            |
| **無線通信**                           |                                                         |                                                         |
| TransceiverPickupTrigger.cs            |                                                         |                                                         |
| **その他**                             |                                                         |                                                         |
| SecretActions.cs                       |                                                         | `SecretActions` (Toolkit)                               |
| SoundOcclusion.cs                      |                                                         | `SoundOcclusion` (Toolkit)                              |

依存関係については、こちらで見るのを推奨→ `https://github.com/Unity-Technologies/com.unity.search.extensions.git?path=package`
