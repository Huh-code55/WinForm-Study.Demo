# MTHProject — 温湿度集中监控系统

基于 **.NET Framework 4.7.2 + WinForms** 的工业现场温湿度集中监控上位机，面向 6 路采集站点的配方生产场景。具备实时采集、配方管理、趋势分析、历史归档、报警管理和用户权限全套闭环功能。

## 功能一览

- **实时监控** — 6 路站点温度/湿度实时采集与刷新，StripChartX 趋势曲线（SeeSharpTools.JY.GUI）
- **配方管理** — 多配方增删改查，当前配方一键切换，配方参数下发到 PLC
- **历史数据** — SQL Server 存储历史采样，支持按时间/设备检索与 Excel 导出
- **报警管理** — 基于阈值的本地报警判定（上限/下限），报警记录归档与确认
- **变量/设备/分组配置** — 采集变量与 Modbus 点位绑定、设备分组管理
- **用户管理** — 账号/角色/权限，登录校验（SHA256 加盐）
- **系统日志** — 关键操作日志记录

## 技术栈

| 类别 | 选型 |
|---|---|
| 运行时 | .NET Framework 4.7.2 |
| UI | WinForms + 自定义控件库（`MTHControlLib`） |
| 图表 | SeeSharpTools.JY.GUI StripChartX |
| 数据库 | SQL Server（ADO.NET 手写，无 ORM） |
| 配置 | ini 文件 + `IniConfigHelper`（UTF-8/GBK 双编码兼容） |
| 通信 | Modbus TCP（`MTHHelper.ModbusTCP`） |
| JSON | Newtonsoft.Json |
| Excel | MiniExcel |
| 数据转换 | thinger.DataConvertLib |

## 分层结构

```
MTHProject.slnx
├── MTHModels        # 实体与枚举：ActualData、RecipeInfo、RecipeParam、SysAdmin、SysLog、Device/Group/Variable
├── MTHHelper        # 通用工具：ModbusTCP、IniConfigHelper（双编码）、JSONHelper
├── MTHDAL           # 数据访问层：SQLHelper（连接串读取 + 通用 SqlCommand 封装）、ActualDataService、SysAdminService、SysLogService
├── MTHBLL           # 业务逻辑层：ActualDataManage、SysAdminManage、SysLogManage
├── MTHControlLib    # 自定义 WinForms 控件：MTHControl、NaviButton、PanelEnhanced、PanelEx、CheckBoxEx、DialPlate、RecipeControl、TextSet、Title
└── MTHProject       # 主程序（WinExe）：FrmLogin / FrmMain / FrmMonitor / FrmRecipe / FrmHistory / FrmAlarm / FrmUserManage / FrmVariableConfig / FrmGroupConfig / FrmParamSet / FrmModify
```

依赖方向：`MTHProject → MTHBLL → MTHDAL → MTHHelper + MTHModels`，`MTHControlLib` 和 `MTHHelper` 独立。

## 运行环境

- Windows 10/11（WinForms 必须有桌面会话）
- Visual Studio 2022 或 .NET Framework 4.7.2 Developer Pack + MSBuild
- SQL Server（任意版本，Express 即可）

## 运行步骤

1. **还原 NuGet 包**（首次）
   ```powershell
   nuget restore MTHProject.slnx
   ```

2. **准备数据库**

   创建 SQL Server 数据库并执行建表脚本（项目未附带脚本，需根据模型自行创建，或参照已部署实例的表结构）。

3. **修改连接串**

   程序在首次启动时会自动在运行目录生成 `Device.ini`，其中 `[数据库]` 节的 `ConnectionString` 是标准 .NET 连接串，例如：

   ```ini
   [数据库]
   ConnectionString=Data Source=localhost;Initial Catalog=MTHDB;Integrated Security=True;
   ```

4. **编译 & 运行**

   用 Visual Studio 直接打开 `MTHProject.slnx`，按 F5。或命令行：

   ```powershell
   msbuild MTHProject.slnx /t:Build /p:Configuration=Debug
   .\MTHProject\bin\Debug\MTHProject.exe
   ```

5. **登录**

   | 用户名 | 密码 |
   |--------|------|
   | admin | admin |
   | operator | operator |
   | engineer | engineer |

   密码存 SHA256 加盐哈希，初始值由部署脚本或首次启动时写入。

## 目录说明

| 路径 | 说明 |
|---|---|
| `MTHProject\CommonMethods.cs` | 全局静态入口：当前设备实例、Modbus 客户端、日志快捷方法 |
| `MTHProject\DataGridViewHelper.cs` | 辅助方法：行号绘制（`RowPostPaint`）、列标题去高亮 |
| `MTHHelper\ModbusTCP.cs` | 手写 Modbus TCP 客户端，支持 0x03/0x06/0x10 功能码 |
| `MTHHelper\IniConfigHelper.cs` | ini 读写，先 UTF-8 解析、GBK 回退（解决 Win32 API `GetPrivateProfileString` 读 UTF-8 中文键乱码的问题） |
| `MTHDAL\SQLHelper.cs` | 连接串读取（调用 IniConfigHelper） + 通用 `GetDataSet` / `ExecuteNonQuery` 封装 |
| `MTHControlLib\*` | 自绘 WinForms 控件，均继承自 `UserControl` |
