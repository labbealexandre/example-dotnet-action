README title checker

# Usage

```bash
docker build . -t github-action
docker run -v ./examples:/examples github-action /app/entrypoint.sh /examples/invalid/README.1.md
/examples/invalid/README.1.md
```
