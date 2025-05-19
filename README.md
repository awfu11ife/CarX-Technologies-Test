# CarX Tower Defense

## 🎯 Цель проекта
Создать архитектурно чистую и расширяемую Tower Defense игру, с упором на масштабируемость, тестируемость и производительность. Все системы реализуются без использования сторонних ассетов — только возможности Unity.

---

## 🧱 Архитектура

Проект построен по принципам SOLID, Composition over Inheritance и DI через ServiceLocator.

### 📁 Структура:
- `Runtime/Core/Services` — базовые сервисы (TickManager, Pool, TargetRegistry)
- `Runtime/Infrastructure/Pooling` — компонентный пуллинг через IPoolable
- `Runtime/GamePlay/Towers` — реализация башен и стратегий
- `Runtime/GamePlay/Enemies` — архитектура врагов
- `Runtime/GamePlay/Projectiles` — все снаряды

---

## Башни
- **CannonTower** — упреждение + прямолинейный снаряд
- **CrystalTower** — выпускает самонаводящиеся снаряды
- Используют стратегии: IAimingStrategy, IShootingStrategy, ITargetingStrategy

## Враги
- Базируются на EnemyBase + EnemyHealth
- Поддерживают движения через IEnemyMovement
- Спавнятся с заданным endPoint и исчезают по достижению

## Снаряды
- `LinearProjectile` — прямолинейный, с упреждением
- `HomingProjectile` — самонаводящийся

## Пуллинг
- `ComponentPoolService`
- `IPoolable` — отслеживание оригинального префаба

---

## Геймплей
- GameInstaller инициализирует сервисы
- EnemySpawner создаёт врагов с траекторией
- Башни ищут цель и стреляют снарядами
- Снаряды наносят урон, враги погибают

---

## ✅ TODO

### Архитектура
- [ ] IProjectile интерфейс

### Снаряды
- [x] LinearProjectile
- [x] HomingProjectile
- [ ] ParabolicProjectile

### Башни
- [x] Захват и сопровождение цели
- [ ] Настройка поворота
 
### Враги
- [x] EnemyBase, EnemyHealth
- [ ] Получение урона

### Пул
- [ ] Для каждого IPoolable свой родительский объект

### Геймплей
- [ ] WaveController

### UI и отладка
- [ ] Gizmos для отладки башен

---

## 📌 Примечания
- Проект работает полностью на Unity без сторонних библиотек.