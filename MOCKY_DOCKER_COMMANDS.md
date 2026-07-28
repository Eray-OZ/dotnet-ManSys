# Mocky Docker Commands

## Start Mocky

Run this command from any directory:

```bash
docker run --rm -p 8888:8888 \
  -v /Users/erayoz/Codes/mocky/mocky/mansys-mock-api:/app \
  -w /app \
  php:8.3-cli \
  php -d display_errors=0 -d error_reporting=22527 \
  -S 0.0.0.0:8888 -t public public/index.php
```

Mocky will be available at:

```text
http://127.0.0.1:8888
```

The root URL may return `Not Found`. Use the setup and provider endpoints below.

## Activate The Quote Scenario

Before calling the mock provider endpoints, activate the test scenario:

```bash
curl http://127.0.0.1:8888/setup/default/kasko-quotes
```

Expected response:

```json
{"status":200,"message":"test name set to 'kasko-quotes' - test scope set to 'default'"}
```

## Test Provider Endpoints

Open Casco:

```bash
curl -X POST http://127.0.0.1:8888/companies/open-casco/quotes \
  -H "Content-Type: application/json" \
  -d "{}"
```

Trust Casco:

```bash
curl -X POST http://127.0.0.1:8888/companies/trust-casco/quotes \
  -H "Content-Type: application/json" \
  -d "{}"
```

Unity Casco:

```bash
curl -X POST http://127.0.0.1:8888/companies/unity-casco/quotes \
  -H "Content-Type: application/json" \
  -d "{}"
```

## Stop Mocky

Press `Ctrl+C` in the terminal where Mocky is running.

If Mocky is running in the background, find and stop the container:

```bash
docker ps
docker stop <container-id-or-name>
```

## Notes

- The provider endpoints are `POST` endpoints. Opening them directly in a browser sends a `GET` request and may return `Not Found`.
- The PHP flags disable deprecation warnings in the HTTP response body. This keeps the response as valid JSON for .NET deserialization.
