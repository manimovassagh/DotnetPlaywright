# 📑 Test Categories & Lanes

This document defines how we classify and run automated tests in this project.  
Each test should be annotated with **[Category]** attributes in NUnit so we can filter easily in CI/CD.

---

## 🎯 Categories by Intent

| Category   | Purpose                                                                 | Run Frequency |
|------------|-------------------------------------------------------------------------|---------------|
| `smoke`    | Minimal set proving the app is alive. Covers only **critical paths** (app loads, login, one core flow). | Every PR, every deploy |
| `sanity`   | Quick validation of main flows + recent changes. Wider than smoke but still fast. | Nightly, after merges |
| `regression` | Full functional coverage including edge cases, negative paths, browser variations. | Before releases, weekly full run |
| `exploratory` *(optional)* | Ad-hoc helpers, unstable experiments. Not part of CI gates. | Local only |

---

## 🧩 Categories by Scope

| Category   | Scope of the test |
|------------|------------------|
| `ui`       | Browser end-to-end (Playwright). |
| `api`      | HTTP / service calls. |
| `component`| Smaller UI pieces or API contract checks. |
| `integration` | Multiple services working together. |

---

## 🔥 Categories by Priority

| Category | Meaning                        |
|----------|--------------------------------|
| `p0`     | Must never break (checkout, login, payment). |
| `p1`     | Important but not release-blocking. |
| `p2`     | Nice-to-have or low-impact.    |

---

## 🛠️ How to Tag Tests

Example in NUnit:

```csharp
[Test]
[Category("ui")]
[Category("smoke")]
[Category("p0")]
public async Task Can_Login()
{
    // test code
}