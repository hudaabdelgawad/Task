var resourceStrings = {};
$(document).ready(function () {
    //call resource from resourcecontroller
    $.ajax({
        url: '/Resource/GetResourceStrings',
        method: 'GET',
        success: function (data) {
            resourceStrings = data;
        },
        error: function () {
            console.error('Error loading resource strings');
        }
    });

    // دالة لمراقبة نشاط المستخدم
    var inactivityTime = function () {
        var time;

        // إعادة ضبط المؤقت عند اكتشاف أي نشاط
        function resetTimer() {
            clearTimeout(time);
            time = setTimeout(logout, 120000);  // 120000 ميلي ثانية = 2 دقائق
        }

        // دالة تسجيل الخروج
        function logout() {
            // عرض نافذة تأكيد تسأل المستخدم إذا كان يرغب في الاستمرار
            if (confirm(resourceStrings.confirm)) {
                resetTimer();  // إعادة ضبط المؤقت إذا اختار المستخدم الاستمرار
            } else {
                window.location.href = '/Account/Logout';  
            }
        }

        // تعيين الأحداث لإعادة ضبط المؤقت عند النشاط
        window.addEventListener('load', resetTimer, true);
        document.addEventListener('mousemove', resetTimer, true);
        document.addEventListener('keypress', resetTimer, true);
        document.addEventListener('click', resetTimer, true);
        document.addEventListener('scroll', resetTimer, true);
        document.addEventListener('touchstart', resetTimer, true);
    };

    // استدعاء دالة مراقبة النشاط
    inactivityTime();
});

$(document).ready(function () {
    function adjustIcons() {
        if ($(window).width() <= 768) {
            $('.icon-home').hide();
            $('.icon-invoice').show();
        } else {
            $('.icon-home').show();
            $('.icon-invoice').hide();
        }
    }

    adjustIcons(); // Initial check
    $(window).resize(function () {
        adjustIcons();
    });
});
