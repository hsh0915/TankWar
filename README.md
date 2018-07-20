# TankWar
坦克大战游戏
韩少华
【实验名称】
坦克大战游戏
【实验目的】
利用vb.net 2008相关控件及功能实现玩家坦克和敌人坦克相互攻击及碰撞检测；玩家坦克通过一些辅助道具（定时器，炸弹，星星）对敌人坦克造成一些特殊效果及增强自身的速度和子弹的威力；游戏中设置的一些障碍道具（草，土墙，钢墙，河流，雪）等等功能。
【掌握内容】
通过这个游戏，掌握了vb.net 的基本语法、控件、以及事件对多种效果处理的简洁性，对面向对象有了更深一步的理解和认识。
【问题描述及基本要求】
玩家登陆后，登陆界面有 “单人游戏” “双人游戏”两个游戏模式供玩家选择，“地图编辑”可以供玩家自己编辑地图（此功能尚未实现），界面左下角有“操作声明”按钮。
<注意！！>！！！ 因为此游戏的音乐效果用了Microsoft.DirectX.dll和Microsoft.DirectX.DirectSound.dll插件，在项目资源加载时会警告，无法正常开始游戏 ，所以我把这两个dll插件也考了进来 。运行游戏前 把这两个dll插件拷在“c:-Program Files (x86)- Reference Assemblies-Microsoft-Framework-v3.5”，然后在vb.net “项目-属性-引用”把这俩个dll 文件加载进来。
【算法描述】
形式化语言描述。
【调试结果及说明】
（1）	本程序的运行环境为VB.NET。

（2）	运行程序后出现游戏界面 有“单人游戏” “双人游戏”两种模式供玩家选择
      
（3）	界面右边给出玩家坦克和敌人坦克数量的缩略图 ，敌人总共12个，地图上每次最多6个敌人 ，玩家生命值为2.

（4）	障碍道具的说明：
      
钢墙：阻碍坦克前进，坦克子弹无法穿过，remove不掉
土墙：阻碍坦克前进，坦克子弹可以让其remove。
河流：阻碍坦克前进, 坦克子弹可以穿过，remove不掉。
雪 : 加速坦克前进，坦克子弹可以穿过，remove不掉。
草 ：不影响坦克前进，影响坦克子弹的速度。
![Image text](https://github.com/hsh0915/TankWar/blob/master/Sourses/1.png)
![Image text](https://github.com/hsh0915/TankWar/blob/master/Sourses/2.png)
![Image text](https://github.com/hsh0915/TankWar/blob/master/Sourses/3.png)
 

