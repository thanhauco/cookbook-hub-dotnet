# Security Policy

## Supported Versions

We release patches for security vulnerabilities. Which versions are eligible for receiving such patches depends on the CVSS v3.0 Rating:

| Version | Supported          |
| ------- | ------------------ |
| 1.0.x   | :white_check_mark: |
| < 1.0   | :x:                |

## Reporting a Vulnerability

Please report (suspected) security vulnerabilities to **security@cookbookhub.com**. You will receive a response from us within 48 hours. If the issue is confirmed, we will release a patch as soon as possible depending on complexity.

### What to Include

When reporting a vulnerability, please include:

- Type of issue (e.g. SQL injection, XSS, authentication bypass)
- Full paths of source file(s) related to the manifestation of the issue
- The location of the affected source code (tag/branch/commit or direct URL)
- Any special configuration required to reproduce the issue
- Step-by-step instructions to reproduce the issue
- Proof-of-concept or exploit code (if possible)
- Impact of the issue, including how an attacker might exploit it

### What to Expect

- Acknowledgment of your report within 48 hours
- Regular updates on our progress
- Credit in the security advisory (unless you prefer to remain anonymous)

## Security Best Practices

### For Developers

1. **Input Validation**: Always validate and sanitize user input
2. **SQL Injection**: Use parameterized queries (EF Core handles this)
3. **XSS Protection**: Blazor automatically encodes output
4. **Authentication**: Implement proper authentication and authorization
5. **HTTPS**: Always use HTTPS in production
6. **Dependencies**: Keep dependencies up to date
7. **Secrets**: Never commit secrets to the repository

### For Users

1. Use strong, unique passwords
2. Enable two-factor authentication when available
3. Keep your browser and operating system up to date
4. Be cautious of phishing attempts
5. Report suspicious activity immediately

## Known Security Considerations

### Current Implementation

- **Authentication**: Not yet implemented (planned for v2.0)
- **Authorization**: Not yet implemented (planned for v2.0)
- **Rate Limiting**: Not yet implemented (planned for v1.1)
- **CSRF Protection**: Blazor WebAssembly provides built-in protection

### Planned Security Features

- JWT-based authentication
- Role-based authorization
- API rate limiting
- Account lockout after failed login attempts
- Password complexity requirements
- Two-factor authentication
- Security headers (HSTS, CSP, etc.)

## Security Updates

We will publish security advisories for any confirmed vulnerabilities. Subscribe to our GitHub repository to receive notifications.

## Disclosure Policy

When we receive a security bug report, we will:

1. Confirm the problem and determine affected versions
2. Audit code to find any similar problems
3. Prepare fixes for all supported versions
4. Release new versions as soon as possible

We appreciate your efforts to responsibly disclose your findings and will make every effort to acknowledge your contributions.
